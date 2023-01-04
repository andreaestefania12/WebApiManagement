import { ContractRule } from "@/services/validator/rules/ContractRule";

export class RequiredRule implements ContractRule {
  validationMessage: string;

  constructor(validationMessage: string) {
    this.validationMessage = validationMessage;
  }

  check(value: string, otherValue?: string): boolean {
    return value !== null && value !== "";
  }
}
