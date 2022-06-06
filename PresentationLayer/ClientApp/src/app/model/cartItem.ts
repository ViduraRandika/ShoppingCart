export interface CartItem{

	[index: number]:{
		id:number;
		cartId:number;
		productName:string;
		price:number;
		productId:number;
		qty:number;
	}
}