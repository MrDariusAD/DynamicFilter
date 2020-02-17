import { AttributeType } from './AttributeType.enum';

export interface Attribute {
    Name: string;
    Value: string;
    Type: AttributeType;
}
