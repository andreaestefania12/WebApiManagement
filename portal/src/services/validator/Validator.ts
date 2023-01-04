import { ContractRule } from "@/services/validator/rules/ContractRule";

export interface GenericField {
  val: string;
  errors: string[];
  isSuccess: boolean;
  enabled: boolean;
  rules: ContractRule[];
}

export function Validator() {
  function validateField(
    field: GenericField,
    otherValue?: string
  ): GenericField {
    field.errors = field.rules
      .filter((rule) => !rule.check(field.val, otherValue))
      .map((rule) => rule.validationMessage);
    field.isSuccess = field.errors.length === 0;
    return field;
  }

  return {
    validateField,
  };
}
