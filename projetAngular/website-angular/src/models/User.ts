import { Guid } from "guid-typescript";


export class User{
    private _id : Guid = Guid.create();
    private _firstName : string = '';


    private _lastName : string  = '';
    private _email : string ='';
    private _phone : string ='';
    private _siret : string = '';

    private _password :string = '';
    private _token : string = '';



    constructor(_id : Guid,  _firstName : string ,_lastName : string ,_email : string, _phone: string,_siret : string, _token : string){
        this._id = _id;
        this._firstName = _firstName;
        this._lastName = _lastName;
        this._email = _email;
        this._phone = this._phone;
        this._siret = _siret;
        this._token = _token;
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