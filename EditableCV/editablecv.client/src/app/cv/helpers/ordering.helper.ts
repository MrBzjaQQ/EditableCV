export function orderByDateDescending<T>(
    collection: T[] | null | undefined,
    compareSelector: (itemA: T) => string | undefined) {
    if (!collection?.length)
        return [];

    return collection.sort((a, b) => {
        const strDateA = compareSelector(a);
        const strDateB = compareSelector(b);
        if (!strDateA)
            return -1;

        if (!strDateB)
            return 1;

        var dateA = Date.parse(strDateA);
        var dateB = Date.parse(strDateB);
        return dateB - dateA;
    });
}