export class OrderListItem {
    constructor(
        public sportNutritionOrderID: number,
        public price: number,
        public quantity: number,
        public totalPrice: number,
        public sportNutritionClientID : number,
        public orderDate : string,
        public deliveryDate : string,
        public country : string,
        public city : string
    ) { }
}
