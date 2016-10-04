import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { EntityCollectionService } from "../services";
import { AppState, AppStore } from "../store";
import { ENTITY_COLLECTION_ADD_SUCCESS, ENTITY_COLLECTION_GET_SUCCESS, ENTITY_COLLECTION_REMOVE_SUCCESS } from "../constants";
import { EntityCollection } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class EntityCollectionActions {
    constructor(private _entityCollectionService: EntityCollectionService, private _store: AppStore) { }

    public add(entityCollection: EntityCollection) {
        const newGuid = guid();
        this._entityCollectionService.add(entityCollection)
            .subscribe(entityCollection => {
                this._store.dispatch({
                    type: ENTITY_COLLECTION_ADD_SUCCESS,
                    payload: entityCollection
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._entityCollectionService.get()
            .subscribe(entityCollections => {
                this._store.dispatch({
                    type: ENTITY_COLLECTION_GET_SUCCESS,
                    payload: entityCollections
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._entityCollectionService.remove({ id: options.id })
            .subscribe(entityCollection => {
                this._store.dispatch({
                    type: ENTITY_COLLECTION_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._entityCollectionService.getById({ id: options.id })
            .subscribe(entityCollection => {
                this._store.dispatch({
                    type: ENTITY_COLLECTION_GET_SUCCESS,
                    payload: [entityCollection]
                });
                return true;
            });
    }
}
