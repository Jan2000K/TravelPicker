export default class DateService{
    static formatDate(val:Date){
        return `${val.getDate()}.${val.getMonth()+1}.${val.getFullYear()} ${val.getHours()}:${val.getMinutes()}`
    }
}