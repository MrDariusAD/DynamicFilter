import { Attribute } from './Attribute';
import { AttributeGroup } from './AttributeGroup';

export interface Item {
    id: string;
    name: string;
    description: string;
    attributes: Attribute[];
    attributeGroups: AttributeGroup[];
    iconUrl: string;
    websiteUrl: string;
}
