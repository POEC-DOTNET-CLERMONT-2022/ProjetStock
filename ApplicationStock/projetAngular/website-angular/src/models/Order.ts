import { Guid } from "guid-typescript"
import { Stock } from "./Stock";
export class Order{

 
    private _id  : Guid = Guid.createEmpty();
    private _orderName : string = '';
    private _orderDate : Date = new Date();

  
    private _nbStock :number = 0
    private _stock : Stock =  new Stock(Guid.createEmpty(),'',5,'');

    constructor(_id : Guid,_orderName :string,_orderDate : Date,_stock : Stock,_nbStock : number){
        this._id = _id;
        this._orderDate= _orderDate;
        this.orderName = _orderName;
        this._stock = _stock;
        this._nbStock = _nbStock
    }

    

    /**
     * Getter nbStock
     * @return {number }
     */
	public get nbStock(): number  {
		return this._nbStock;
	}

    /**
     * Setter nbStock
     * @param {number } value
     */
	public set nbStock(value: number ) {
		this._nbStock = value;
	}
      /**
     * Getter stock
     * @return {Stock }
     */
	public get stock(): Stock  {
		return this._stock;
	}

    /**
     * Setter stock
     * @param {Stock } value
     */
	public set stock(value: Stock ) {
		this._stock = value;
	}
       /**
     * Getter orderName
     * @return {string }
     */
	public get orderName(): string  {
		return this._orderName;
	}

    /**
     * Setter orderName
     * @param {string } value
     */
	public set orderName(value: string ) {
		this._orderName = value;
	}
    /**
     * Getter orderDate
     * @return {Date }
     */
	public get orderDate(): Date  {
		return this._orderDate;
	}

    /**
     * Setter orderDate
     * @param {Date } value
     */
	public set orderDate(value: Date ) {
		this._orderDate = value;
	}
 
    /**
     * Getter $stock
     * @return {Stock }
     */
	public get $stock(): Stock  {
		return this._stock;
	}

    /**
     * Setter $stock
     * @param {Stock } value
     */
	public set $stock(value: Stock ) {
		this._stock = value;
	}

}