import { Guid } from "guid-typescript"

export class Stock{

    private _id : Guid = Guid.create();
    private _name : string = '';
    private _value : number =0;
    private _entrepriseName : string = '';

    constructor(_id :Guid, _name : string, _value :number,_entrepriseName :string){
        this._id = _id;
        this._name = _name;
        this._value = _value;
        this._entrepriseName = _entrepriseName;

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
    public set id(value: Guid ) {
        this._id = value;
    }
    /**
     * Getter id
     * @return {number}
     */
     public get value(): number  {
        return this._value;
    }

    /**
     * Setter id
     * @param {Number } value
     */
    public set value(value: number ) {
        this._value = value;
    }

                /**
     * Getter _name
     * @return {string }
     */
	public get Name(): string {
		return this._name;
	}

    /**
     * Setter textRappel
     * @param {string } value
     */
	public set Name(value: string ) {
		this._name = value;
	}
    /**
    * Getter _name
    * @return {string }
    */
   public get entrepriseName(): string {
       return this._entrepriseName;
   }

   /**
    * Setter textRappel
    * @param {string } value
    */
   public set entrepriseName(value: string ) {
       this._entrepriseName = value;
   }


}