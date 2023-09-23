import { Patient } from '../../patients/shared/patient.model';
import {
  NgForm,
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  ReactiveFormsModule,
  ValidatorFn
} from '@angular/forms';
import * as moment from "moment/moment";

export class Visit {
  public PatientId: number = 0;
  public PatientVisitId: number = 0;
  public VisitCode: string = "";
  public VisitDate: string = moment().toISOString().split('T')[0];
  public DepartmentId: number = null;
  public DepartmentName: string = null;
  public Diagnosis: string = "";
  public ProviderId: number = 0;
  public ProviderName: string = null;
  public Comments: string = null;
  public ReferredByProvider: string = null;
  public VisitType: string = null;
  public VisitStatus: string = null;
  public VisitTime: string = moment().add(5, 'minutes').format('HH:mm');
  public VisitDuration: number = 0;
  public Patient: Patient = null;
  public AppointmentId: number = null;
  public BillingStatus: string = null;
  public ReferredByProviderId: number = null;
  public AppointmentType: string = null;
  public ParentVisitId: number = null;
  public IsVisitContinued: boolean = false;
  public CreatedOn: string = null;
  public CreatedBy: number = null;
  public IsActive: boolean = true;
  public ModifiedBy: number = null;
  public ModifiedOn: string = null;
  public Remarks: string = null;
  public QueueNo: number = 0;
  public VisitValidator: FormGroup = null;
  public IsValidSelProvider: boolean = true;
  public IsValidSelDepartment: boolean = true;
  public IsSignedVisitSummary: boolean = false;
  public TransferredProviderId: number = null;
  public ClaimCode: number = null;
  public CurrentCounterId: number = null;
  public ConcludeDate: string = null;
  public ERTabName: string = null;
  public DeptRoomNumber: string = null;
  public Ins_HasInsurance: boolean = null;
  public IsLastClaimCodeUsed: boolean = false;
  public ShortName: string = null;
  public PatientCode: string = null;
  public CountryId: number = 0;
  public CountrySubDivisionId: number = 0;

  public IsDirty(fieldname): boolean {
    if (fieldname == undefined) {
      return this.VisitValidator.dirty;
    } else {
      return this.VisitValidator.controls[fieldname].dirty;
    }
  }

  public IsValid(): boolean {
    return this.VisitValidator.valid;
  }

  public IsValidCheck(fieldname, validator): boolean {
    if (!this.VisitValidator.dirty) {
      return true;
    }
    if (fieldname == undefined) {
      return this.VisitValidator.valid;
    } else {
      return !(this.VisitValidator.hasError(validator, fieldname));
    }
  }

  constructor() {
    var _formBuilder = new FormBuilder();
    this.VisitValidator = _formBuilder.group({
      'VisitDate': ['', Validators.compose([Validators.required, this.DateValidator])],
      'VisitTime': ['', Validators.compose([Validators.required])],
      'Doctor': ['', Validators.compose([Validators.required])],
      'Department': ['', Validators.compose([Validators.required])],
      'ClaimCode': ['', Validators.compose([Validators.required])],
    }, { validator: this.DateTimeValueValidator('VisitDate', 'VisitTime') });
  }

  public DateValidator(control: FormControl): { [key: string]: boolean } {
    if (control && control.value) {
      let _date = control.value;
      var _currDate = moment().format('YYYY-MM-DD');
      if (moment(_date).diff(_currDate) < 0) {
        return { 'invalidDate': true };
      }
    }
  }

  public IsValidDateTime(validator): boolean {
    if (!this.VisitValidator.dirty) {
      return true;
    } else {
      return !(this.VisitValidator.hasError(validator));
    }
  }

  public UpdateValidator(onOff: string, formControlName: string, validatorType: string) {
    let validator = null;
    if (validatorType == 'required' && onOff == "on") {
      validator = Validators.compose([Validators.required]);
    } else {
      validator = Validators.compose([]);
    }
    this.VisitValidator.controls[formControlName].validator = validator;
    this.VisitValidator.controls[formControlName].updateValueAndValidity();
  }

  public DateTimeValueValidator(targetKey: string, toMatchKey: string): ValidatorFn {
    return (group: FormGroup): { [key: string]: any } => {
      const target = group.controls[targetKey];
      const toMatch = group.controls[toMatchKey];
      if (target && target.value && toMatch && toMatch.value) {
        let _date = target.value;
        let _time = toMatch.value;
        let _dateTime = moment(_date + " " + _time);
        var _currDate = moment().format('YYYY-MM-DD HH:mm');
        if (moment(_dateTime).diff(_currDate) < 0) {
          return { 'invalidDateTime': true };
        }
      }
    };
  }

  ngOnDestroy() {
    clearInterval();
  }

  public EnableControl(formControlName: string, enabled: boolean) {
    let currCtrol = this.VisitValidator.controls[formControlName];
    if (currCtrol) {
      if (enabled) {
        currCtrol.enable();
      } else {
        currCtrol.disable();
      }
    }
  }
}

