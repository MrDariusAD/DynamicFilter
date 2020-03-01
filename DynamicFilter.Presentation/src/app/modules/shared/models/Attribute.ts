import { AttributeType } from './AttributeType.enum';

export interface Attribute {
    name: string;
    value: string;
    type: AttributeType;
    weight?: number;
}
