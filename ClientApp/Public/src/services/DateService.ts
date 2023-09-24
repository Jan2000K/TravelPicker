export default class DateService{
    static formatDate(val:Date){
        return `${val.getDate()}.${val.getMonth()+1}.${val.getFullYear()} ${String(val.getHours()).padStart(2,'0')}:${String(val.getMinutes()).padStart(2,'0')}`
    }
}