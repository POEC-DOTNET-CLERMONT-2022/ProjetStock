import { Guid } from "guid-typescript"

export class Notification{
   private _id : Guid = Guid.create();
   private _textRappel : string = '';
   private _sendAt : Date;


   constructor(_id: Guid , textRappel : string, _sendAt : Date){
       this._id = _id;
       this._textRappel = textRappel;
       this._sendAt = _sendAt;
       
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
     * Getter textrappel
     * @return {string }
     */
	public get TextRappel(): string {
		return this._textRappel;
	}

    /**
     * Setter textRappel
     * @param {Guid } value
     */
	public set TextRappel(value: string ) {
		this._textRappel = value;
	}


                 /**
     * Getter _sendat
     * @return {string }
     */
	public get SendAt(): Date{
		return this._sendAt;
	}

    /**
     * Setter textRappel
     * @param {Guid } value
     */
	public set SendAt(value: Date ) {
		this._sendAt = value;
	}

}