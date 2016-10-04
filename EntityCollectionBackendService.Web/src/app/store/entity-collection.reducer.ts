import { Action } from "@ngrx/store";
import { ENTITY_COLLECTION_ADD_SUCCESS, ENTITY_COLLECTION_GET_SUCCESS, ENTITY_COLLECTION_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { EntityCollection } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const entityCollectionsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ENTITY_COLLECTION_ADD_SUCCESS:
            var entities: Array<EntityCollection> = state.entityCollections;
            var entity: EntityCollection = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { entityCollections: entities });

        case ENTITY_COLLECTION_GET_SUCCESS:
            var entities: Array<EntityCollection> = state.entityCollections;
            var newOrExistingEntityCollections: Array<EntityCollection> = action.payload;
            for (let i = 0; i < newOrExistingEntityCollections.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingEntityCollections[i] });
            }                                    
            return Object.assign({}, state, { entityCollections: entities });

        case ENTITY_COLLECTION_REMOVE_SUCCESS:
            var entities: Array<EntityCollection> = state.entityCollections;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { entityCollections: entities });

        default:
            return state;
    }
}

