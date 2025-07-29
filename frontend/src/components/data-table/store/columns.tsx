"use client";
import { Store } from "@/app/stores/_types/store";
import { ColumnDef } from "@tanstack/react-table";

const columns: ColumnDef<Store>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    accessorKey: "locationId",
    header: "Location Id",
  },
];

export default columns;
