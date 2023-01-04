import { computed, ref, Ref, watch } from "vue";
import { GenericField, Validator } from "@/services/validator/Validator";
import { RequiredRule } from "@/services/validator/rules/RequiredRule";

export function clientValidator(){
    const name: Ref<GenericField> = ref({
        enabled: false,
        errors: [],
        isSuccess: true,
        val: "",
        rules: [new RequiredRule("Se debe agregar un valor")],
    });

    const lastName: Ref<GenericField> = ref({
        enabled: false,
        errors: [],
        isSuccess: true,
        val: "",
        rules: [new RequiredRule("Se debe agregar un valor")],
    });

    const email: Ref<GenericField> = ref({
        enabled: false,
        errors: [],
        isSuccess: true,
        val: "",
        rules: [new RequiredRule("Se debe agregar un valor")],
    });

    const phoneNumber: Ref<GenericField> = ref({
        enabled: false,
        errors: [],
        isSuccess: true,
        val: "",
        rules: [new RequiredRule("Se debe agregar un valor")],
    });

    watch(
        () => name.value.val,
        () => {
            name.value.enabled = true
        }
    );
    
    watch(
        () => lastName.value.val,
        () => (lastName.value.enabled = true)
    );
    
    watch(
        () => email.value.val,
        () => (email.value.enabled = true)
    );
    
    watch(
        () => phoneNumber.value.val,
        () => (phoneNumber.value.enabled = true)
    );

    
   
    function validate(field: GenericField, otherValue?: string) {
        return Validator().validateField(field, otherValue);
    }

    const successForm = computed(() => {
        name.value = validate(name.value);
        lastName.value = validate(lastName.value);
        email.value = validate(email.value);
        phoneNumber.value = validate(phoneNumber.value);
        
        
        return !(
            name.value.isSuccess &&
            lastName.value.isSuccess &&
            email.value.isSuccess &&
            phoneNumber.value.isSuccess 
        );
    });
    return {
        name,
        lastName,
        email,
        phoneNumber,
        successForm
    }
}