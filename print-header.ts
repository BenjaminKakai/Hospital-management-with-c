import { Component, Input } from "@angular/core";
import { CoreService } from "../../core/shared/core.service";
import { MessageboxService } from "../messagebox/messagebox.service";

@Component({
    selector: "print-header",
    templateUrl: "./print-header.html",
})
export class PrintHeaderComponent {
    public headerDetail: any;

    @Input("unit-name") unitname: string = "PHARMACY UNIT";
    @Input("show-pan-number") showPANNo: boolean = true;
    @Input("show-phone-number") showPhoneNo: boolean = true;

    @Input("report-for")
    public reportFor: string = '';
    public isLabReport: boolean = false;
    public isBillingReport: boolean = false;
    public isSystemAdminReport: boolean = false;
    public isMRReport: boolean = false;
    public isADTReport: boolean = false;

    constructor(public coreService: CoreService, public msgBoxServ: MessageboxService) { }

    ngOnInit() {
        this.GetHeaderParameter();
    }

    GetHeaderParameter() {
        if (this.coreService.Parameters && Array.isArray(this.coreService.Parameters)) {
            let paramValue;
            let foundParam = this.coreService.Parameters.find(a => a.ParameterGroupName == "Common" && a.ParameterName == "CustomerHeader");
            switch (this.reportFor) {
                case "billing":
                    this.isBillingReport = true;
                    if (foundParam) paramValue = foundParam.ParameterValue;
                    break;
                case "lab":
                    this.isLabReport = true;
                    if (foundParam) paramValue = foundParam.ParameterValue;
                    break;
                case "adt":
                    this.isADTReport = true;
                    if (foundParam) paramValue = foundParam.ParameterValue;
                    break;
                case "MRReport":
                    this.isMRReport = true;
                    if (foundParam) paramValue = foundParam.ParameterValue;
                    break;
                case "systemadmin":
                    this.isSystemAdminReport = true;
                    if (foundParam) paramValue = foundParam.ParameterValue;
                    break;
                default:
                    foundParam = this.coreService.Parameters.find(a => a.ParameterGroupName == "Pharmacy" && a.ParameterName == "Pharmacy Receipt Header");
                    if (foundParam) paramValue = foundParam.ParameterValue;
                    break;
            }
            if (paramValue) {
                this.headerDetail = JSON.parse(paramValue);
            } else {
                this.msgBoxServ.showMessage("error", ["Please enter parameter values for the respective header"]);
            }
        } else {
            this.msgBoxServ.showMessage("error", ["Parameters are not loaded correctly. Please check the CoreService initialization."]);
        }
    }
}

