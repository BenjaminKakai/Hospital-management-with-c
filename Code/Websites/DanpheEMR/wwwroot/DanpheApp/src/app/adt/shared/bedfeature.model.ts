import {
    FormGroup,
    Validators,
    FormBuilder
} from '@angular/forms';

export class BedFeature {
    public BedFeatureId: number = 0;
    public BedFeatureName: string = null;
    public BedFeatureFullName: string = null;
    public BedPrice: number = null;
    public CreatedBy: number = null;
    public ModifiedBy: number = null;
    public IsActive: boolean = true;
    public CreatedOn: string = null;
    public ModifiedOn: string = null;
    public BedFeatureValidator: FormGroup = null;
    public IsSelected: boolean = false;
    public TaxApplicable: boolean = false; // added for adding in Bill Item price table: yubraj 11th Oct 2018

    constructor() {
        const _formbuilder = new FormBuilder();
        this.BedFeatureValidator = _formbuilder.group({
            'BedFeatureName': ['', Validators.compose([Validators.required, Validators.maxLength(50)])],
            'BedFeatureFullName': ['', Validators.compose([Validators.maxLength(100)])],
            'BedPrice': [0, Validators.compose([Validators.required])],
        });
    }

    public IsDirty(fieldName?: string): boolean {
        if (fieldName == undefined) {
            return this.BedFeatureValidator.dirty;
        } else {
            return this.BedFeatureValidator.controls[fieldName].dirty;
        }
    }

    public IsValid(): boolean {
        return this.BedFeatureValidator.valid;
    }

    public IsValidCheck(fieldName: string, validator: string): boolean {
        if (fieldName == undefined) {
            return this.BedFeatureValidator.valid;
        } else {
            return !(this.BedFeatureValidator.hasError(validator, fieldName));
        }
    }
}

