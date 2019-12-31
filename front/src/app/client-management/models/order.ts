export class Order {
    constructor(
        public sportNutritionOrderID: number,
        public sportNutritionClientID: number,
        public price: number,
        public quantity: number,
        public totalPrice: number,
        public orderDate : string,
        public deliveryDate : string,
        public country : string,
        public city : string
    ) { }
}
