import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { EntityCollection } from "../models";
import { Observable } from "rxjs";

import { apiCofiguration } from "../configuration";


@Injectable()
export class EntityCollectionService {
    constructor(private _http: Http) { }

    public add(entity: EntityCollection) {
        return this._http
            .post(`${apiCofiguration.baseUrl}/api/entitycollection/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/entitycollection/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/entitycollection/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${apiCofiguration.baseUrl}/api/entitycollection/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get baseUrl() { return apiCofiguration.baseUrl; }

}
