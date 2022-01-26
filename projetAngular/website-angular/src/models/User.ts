import { Guid } from "guid-typescript";
import { Address } from "./Adress";
import { Stock } from "./Stock";


export class User{
    private _id : Guid = Guid.create();
    private _firstName : string = '';


    private _lastName : string  = '';
    private _email : string ='';
    private _phone : string ='';
    private _siret : string = '';

    private _password :string = '';
    private _token : string = '';

    private _stocks :Stock[] = [];

    constructor(_id : Guid,  _firstName : string ,_lastName : string ,_email : string, _phone: string,_siret : string, _token : string){
        this._id = _id;
        this._firstName = _firstName;
        this._lastName = _lastName;
        this._email = _email;
        this._phone = this._phone;
        this._siret = _siret;
        this._token = _token;
        this._addresses = [];
        this._stocks = [];
    }
    


    /**
     * Getter addresses
     * @return {Address[] }
     */
	public get addresses(): Address[]  {
		return this._addresses;
	}

    /**
     * Setter addresses
     * @param {Address[] } value
     */
	public set addresses(value: Address[] ) {
		this._addresses = value;
	}
    private _addresses : Address[] = [];

    /**
     * Getter stocks
     * @return {Stock[] }
     */
	public get stocks(): Stock[]  {
		return this._stocks;
	}

    /**
     * Setter stocks
     * @param {Stock[] } value
     */
	public set stocks(value: Stock[] ) {
		this._stocks = value;
	}
     /**
     * Setter siret
     * @param {srting } value
     */
   public set token(value: string ) {
     this._token= value;
}


      /**
* Getter email
* @return {string }
*/
public get Password(): string  {
     return this._password;
}
  
  /**
     * Setter siret
     * @param {srting } value
     */
   public set Password(value: string ) {
     this._password= value;
}


    /**
     * Getter phone
     * @return {string }
     */
	public get phone(): string  {
		return this._phone;
	}

    /**
     * Setter phone
     * @param {string } value
     */
	public set phone(value: string ) {
		this._phone = value;
	}

      /**
* Getter email
* @return {string }
*/
public get token(): string  {
     return this._token;
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
     * Getter firstName
     * @return {string }
     */
	public get firstName(): string  {
		return this._firstName;
	}

    /**
     * Setter firstname
     * @param {string } value
     */
	public set firstName(value: string ) {
		this._firstName= value;
	}

    
          /**
     * Getter siret
     * @return {string }
     */
	public get siret(): string  {
		return this._siret;
	}

    /**
     * Setter siret
     * @param {srting } value
     */
	public set siret(value: string ) {
		this._siret= value;
	}
    
    
           /**
     * Getter email
     * @return {string }
     */
	public get email(): string  {
		return this._email;
	}

    /**
     * Setter email
     * @param {srting } value
     */
	public set email(value: string ) {
		this._email= value;
	}
    

           /**
     * Getter lastName
     * @return {string }
     */
	public get lastName(): string  {
		return this._lastName;
	}

    /**
     * Setter lastName
     * @param {srting } value
     */
	public set lastName(value: string ) {
		this._lastName= value;
	}
    
    

}