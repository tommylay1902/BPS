"use client";

import { ColumnDef } from "@tanstack/react-table";
import { Store } from "../../_types/store";
import { locationFormatterToString } from "../../_format/locationFormatter";
import { Checkbox } from "@/components/ui/checkbox";

export const columns: ColumnDef<Store>[] = [
  {
    id: "select",
    header: ({ table }) => (
      <Checkbox
        checked={table.getIsAllRowsSelected()}
        onCheckedChange={(value) => table.toggleAllRowsSelected(!!value)}
      />
    ),
    cell: ({ row }) => (
      <Checkbox
        checked={row.getIsSelected()}
        onCheckedChange={(value) => row.toggleSelected(!!value)}
        disabled={!row.getCanSelect()}
      />
    ),
  },
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
