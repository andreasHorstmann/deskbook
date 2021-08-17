import { IDesk } from "./desk";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IDesk[];
}
