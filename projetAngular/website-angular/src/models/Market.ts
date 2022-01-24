import { Guid } from "guid-typescript"
import { Stock } from "src/models/Stock"

export class Market{
    private _id : Guid = Guid.create();
    private _name : string = '';
    private _openingDate : Date = new Date();
    private _closingDate : Date = new Date();
    private _stocks : Stock[];

    constructor(_id : Guid,_name : string,_openingDate : Date, _closingDate : Date){
        this._id = _id;
        this._name = _name;
        this._openingDate = _openingDate;
        this._closingDate = _closingDate;
        this._stocks = [];
    }


     /**
     * Getter id
     * @return {Guid }
     */
      public get id(): Guid  {
        return this._id;
    }

    /**
     * Setter id
     * @param { } value
     */
    public set Name(value: string ) {
        this._name = value;
    }

      public get Name(): string  {
        return this._name;
    }

  
    public set id(value: Guid ) {
        this._id = value;
    }


    public set OpeningDate(value : Date){
        this._openingDate = value;
    }
    public get OpeningDate(){
        return this._openingDate;
    }

    
    public set addStock(value : Stock){
        this._stocks.push(value);
    }

    public get Stocks(){
        return this._stocks;
    }
    public unStock(int : number){
      return this._stocks[int];
    }
    

    public set ClosingDate(value : Date){
        this._closingDate = value;
    }
    public get ClosingDate(){
        return this._closingDate;
    }
}