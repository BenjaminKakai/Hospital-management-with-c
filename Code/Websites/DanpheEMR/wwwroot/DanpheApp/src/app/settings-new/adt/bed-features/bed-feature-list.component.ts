import { Component, ChangeDetectorRef } from "@angular/core";
import { SettingsService } from '../../shared/settings-service';
import { GridEmitModel } from "../../../shared/danphe-grid/grid-emit.model";
import { BedFeature } from '../../../adt/shared/bedfeature.model';

@Component({
  selector: 'bed-feature-list',
  templateUrl: './bed-feature-list.html',
})
export class BedFeatureListComponent {
 
  public bedFeatureList: Array<BedFeature> = new Array<BedFeature>();
  public showGrid: boolean = false;
  public bedFeatureGridColumns: Array<any> = null;

  public showAddPage: boolean = false;
  public selectedItem: BedFeature;
  public selectedID: null;

  constructor(public settingsServ: SettingsService,
              public changeDetector: ChangeDetectorRef) {
    this.bedFeatureGridColumns = this.settingsServ.settingsGridCols.BedFeatureList;
    // Note: The call to getBedFeature() has been commented out since it was relying on SettingsBLService.
    // If you plan to reintegrate a service like this later, you may need to bring this call back and adjust accordingly.
    // this.getBedFeature(); 
  }
  
  // Commented out the entire getBedFeature function since it relied on SettingsBLService
  // public getBedFeature() {
  //   this.settingsBLService.GetBedFeatureList()
  //     .subscribe(res => {
  //       if (res.Status == "OK") {
  //         this.bedFeatureList = res.Results;
  //         this.showGrid = true;
  //       } else {
  //         alert("Failed ! " + res.ErrorMessage);
  //       }
  //     });
  // }
  
  BedFeatureGridActions($event: GridEmitModel) {
    switch ($event.Action) {
      case "edit": {
        this.selectedItem = null;
        this.selectedID = $event.Data.BedFeatureId;
        this.showAddPage = false;
        this.changeDetector.detectChanges();
        this.selectedItem = $event.Data;
        this.showAddPage = true;
      }
      default:
        break;
    }
  }
  
  AddBedFeature() {
    this.showAddPage = false;
    this.changeDetector.detectChanges();
    this.showAddPage = true;
  }

  CallBackAdd($event) {
    var bedFeature: BedFeature = $event.bedFeature;
    if (this.selectedID != null) {
      let i = this.bedFeatureList.findIndex(a => a.BedFeatureId == bedFeature.BedFeatureId);
      this.bedFeatureList.splice(i, 1, bedFeature);
    } else {
      this.bedFeatureList.push(bedFeature);
    }

    this.bedFeatureList = this.bedFeatureList.slice();
    this.changeDetector.detectChanges();
    this.showAddPage = false;
    this.selectedItem = null;
    this.selectedID = null;
  }
}

