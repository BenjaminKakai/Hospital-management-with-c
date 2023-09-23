import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { CoreService } from '../core/shared/core.service';

export enum APIsByType {
  PatientListForRegNewVisit = "/api/Patient?reqType=patient-search-for-new-visit&search=",
  PatByName = "/api/Patient?reqType=patient-search-by-text&search=",
  BillingPatient = "/api/Patient?reqType=patientsWithVisitsInfo",
  NursingInpatient = "/api/Admission?reqType=getAdmittedList&search=",
  VisitList = "/api/Visit?status=",
  NursingOutpatient = "/api/Visit?reqType=pastVisitList&search=",
  BillingDuplicatePrint = "/api/Billing?reqType=listinvoicewisebill&search=",
  BillingEditDoctor = "/api/Billing?reqType=GetTxnItemsForEditDoctor&search=",
  BillingProvisional = "/api/Billing?reqType=listprovisionalwisebill&search="
}

@Injectable()
export class SearchService {

  public status: string = "";
  public maxdayslimit: number = 0;
  public patientType: string = "";

  constructor(private http: HttpClient, private _coreService: CoreService) { }

  search(apiUrl: string, terms: Observable<string>): Observable<any> {
    return terms.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(term => this.searchEntries(apiUrl, term))
    );
  }

  searchEntries(apiurl: string, term: string): Observable<any> {
    if (term.length === 0 || term.length > this.getSearchCharLength()) {
      switch (apiurl) {
        case APIsByType.VisitList:
          return this.http.get<any>(`${apiurl}${this.status}&dayslimit=${this.maxdayslimit}&search=${term}`).pipe(map(res => res));
        case APIsByType.BillingPatient:
          return this.http.get<any>(`${apiurl}&admitStatus=${this.patientType}&search=${term}`).pipe(map(res => res));
        default:
          return this.http.get<any>(`${apiurl}${term}`).pipe(map(res => res));
      }
    } else {
      return EMPTY;
    }
  }

  getSearchCharLength(): number {
    let length = 0;
    if (this._coreService.Parameters) {
      const filteredList = this._coreService.Parameters.filter(p => p.ParameterGroupName === "Common" && p.ParameterName === "ServerSideSearchCharLength");
      if (filteredList.length > 0) {
        length = filteredList[0].ParameterValue;
      } else {
        length = 2; // default search on 3 characters
      }
    }
    return length;
  }
}

