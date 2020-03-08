import { Attribute } from './Attribute';
import { AttributeGroup } from './AttributeGroup';

export interface AssistantRequestModel {
    preferenceAttributes: Attribute[];
    preferenceAttributeGroups: AttributeGroup[];
}
