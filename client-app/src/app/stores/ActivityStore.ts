import { makeAutoObservable } from "mobx";

export default class ActivityStore{
    title = `Hello!!!`;

    constructor(){
        makeAutoObservable(this)
    }

    setTitle = () => {
        this.title = this.title + `Welcome To Group!`;
    }
}