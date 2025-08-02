"use client";

import { ColumnDef } from "@tanstack/react-table";
import { Store } from "../../_types/store";
import { locationFormatterToString } from "../../_format/locationFormatter";

export const columns: ColumnDef<Store>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    accessorKey: "location",
    header: "Location",
    cell: ({ row }) => (
      <span>{locationFormatterToString(row.original.location)}</span>
    ),
  },
];
