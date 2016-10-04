import { EntityCollection } from "../models";

export interface AppState {
    entityCollections: Array<EntityCollection>;
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
