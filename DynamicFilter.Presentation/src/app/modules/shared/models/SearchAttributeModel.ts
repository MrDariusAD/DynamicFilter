import { AttributeType } from './AttributeType.enum';

export interface SearchAttributeModel {
    name: string;
    type: AttributeType;
    values: string[];
}
