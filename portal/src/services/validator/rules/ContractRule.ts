export interface ContractRule {
    validationMessage: string;
    check(value: string, otherValue?: string): boolean;
  }
  