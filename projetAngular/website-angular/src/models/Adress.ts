import { Guid } from "guid-typescript"

export class Address{
    private _id : Guid = Guid.create();
    private _address_line_1 : string = '';
    private _address_line_2 : string = '';
    private _codePostal : string = '';
    private _city: string = '';
    private _country : string = '';
 
    constructor(_id: Guid ,_address_line_1 : string, _address_line_2 : string, _codePostal : string,_city : string,_country : string){
        this._id = _id;
        this._address_line_1 = _address_line_1;
        this._address_line_2 = _address_line_2;
        this._city = _city;
        this._country = _country;    
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
          * @param {Guid } value
          */
         public set id(value: Guid ) {
             this._id = value;
         }
 
                /**
      * Getter  addressLine1
      * @return {string }
      */
     public get AddressLine1(): string {
         return this._address_line_1;
     }
 
     /**
      * Setter AddressLine1
      * @param {string } value
      */
     public set AddressLine1(value: string ) {
         this._address_line_1 = value;
     }
 
     
           /**
      * Getter  codePostal
      * @return {string }
      */
            public get CodePostal(): string {
                return this._codePostal;
            }
        
            /**
             * Setter AddressLine2
             * @param {string } value
             */
            public set CodePostal(value: string ) {
                this._codePostal= value;
            }

              /**
      * Getter  city
      * @return {string }
      */
               public get City(): string {
                return this._city;
            }
        
            /**
             * Setter city
             * @param {string } value
             */
            public set City(value: string ) {
                this._city= value;
            }
    /**
      * Getter  country
      * @return {string }
      */
     public get Country(): string {
        return this._country;
    }

    /**
     * Setter country
     * @param {string } value
     */
    public set Country(value: string ) {
        this._country= value;
    }


            

}