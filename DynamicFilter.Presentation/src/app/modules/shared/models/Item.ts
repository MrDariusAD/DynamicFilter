import { Attribute } from './Attribute';

export interface Item {
    id: string;
    name: string;
    attributes: Attribute[];
    iconUrl: string;
}
