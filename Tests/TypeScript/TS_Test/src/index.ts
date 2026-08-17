// Simple TypeScript project
export enum weekDays{
    Monday = "Monday",
    Tuesday = "Tuesday",
    Wednesday = "Wednesday",
    Thursday = "Thursday",
    Friday = "Friday"
}
export const employee :{
    empName : string,
    dependents : number,
    committees : [string, boolean],
    payDay? : weekDays
} = {
    empName : "John Doe",
    dependents : 2,
    committees : ["Philanthropy", true],
    payDay : weekDays.Friday
};

export default employee;

