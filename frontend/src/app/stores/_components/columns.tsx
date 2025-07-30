"use client";
import { Store } from "@/app/stores/_types/store";
import { ColumnDef } from "@tanstack/react-table";

const columns: ColumnDef<Store>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    header: "Location",
    cell: (cell) => {
      const location = cell.row.original.location;

      return location
        ? `${location?.city}, ${location?.street}, ${location?.suite}, ${location?.zipCode}`
        : "";
    },
  },
];

export default columns;
