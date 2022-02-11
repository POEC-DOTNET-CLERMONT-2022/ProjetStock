export class DeleteClass{
    private _id : string;
    constructor(_id :string){
        this._id = _id;
    }

    public set Id(value : string){
        this._id = value;
    }

    public get Id(){
        return this._id;
    }
}