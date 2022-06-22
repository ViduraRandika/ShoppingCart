export interface Order{

	[index: number]:{
		orderId:number;
		customerId:number;
		grandTotal:number;
		cartId:number;
		status:string;
		orderDate:string
	}
}