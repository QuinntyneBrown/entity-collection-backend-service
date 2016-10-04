import { EntityCollectionItem } from "./entity-collection-item.model";

export class Categiry { 
	public id:number;
    public name: string;
    public HtmlDescription: string;
    public items: Array<EntityCollectionItem> = [];
}
