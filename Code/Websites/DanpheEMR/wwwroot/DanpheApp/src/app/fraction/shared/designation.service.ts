import { Injectable } from '@angular/core';
import { DesignationEndPoint } from './designation.endpoint';
import { DesignationModel } from './designation.model';

@Injectable()
export class DesignationService {

    constructor(public designationEndpoint: DesignationEndPoint) {

    }

    public GetDesignationList() {
        return this.designationEndpoint.GetDesignationList()
            .map(res => { return res });
    }

    public AddDesignation(CurrentDesignation: DesignationModel) {
        return this.designationEndpoint.AddDesignation(CurrentDesignation)
            .map(res => { return res });
    }

    public UpdateDesignation(id: number, CurrentDesignation: DesignationModel) {
        return this.designationEndpoint.UpdateDesignation(id, CurrentDesignation)
            .map(res => { return res });
    }

    public GetDesignation(id: number) {
        return this.designationEndpoint.GetDesignation(id)
            .map(res => { return res });
    }
}

