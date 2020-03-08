import { SearchAttributeModel } from './SearchAttributeModel';
import { SearchAttributeGroupModel } from './SearchAttributeGroupModel';

export interface PresentAttributesReportModel {
    attributes: SearchAttributeModel[];
    attributeGroups: SearchAttributeGroupModel[];
}