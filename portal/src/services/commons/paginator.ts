import {computed, ref, Ref} from "vue";

export function paginator () {
    const page: Ref<number> = ref(1);
    const maxItems: Ref<number> = ref(100);
    const total: Ref<number> = ref(0);

    const start = computed(() => maxItems.value * (page.value - 1));
    const end = computed(() => maxItems.value * page.value);
    const isFirstPage= computed(() => page.value == 1);
    const isLastPage= computed(() => page.value == Math.ceil(total.value / maxItems.value));

    function nextPage(): number {
        if(!isLastPage.value){
            return (page.value += 1);
        }
        return page.value;
    }

    function previousPage(): number {
        if(!isFirstPage.value){
            return (page.value -= 1);
        }
        return page.value;
    }

    function returnData<T>(data: Array<T>) : Array<T> {
        total.value = data.length;
        return data.slice(start.value, end.value);
    }

    return {
        isFirstPage,
        isLastPage,
        maxItems,
        nextPage,
        previousPage,
        returnData
    };
}