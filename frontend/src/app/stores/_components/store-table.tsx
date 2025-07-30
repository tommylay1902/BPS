import * as React from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
  TableHead,
} from "@/components/ui/table";
import { Store } from "@/app/stores/_types/store";

interface StoreTableProps {
  stores: Store[];
}

const display = new Set(["name", "locationId"]);

const StoreTable: React.FC<StoreTableProps> = ({ stores }) => {
  return (
    <Table>
      <TableHeader>
        <TableRow>
          {Object.keys(stores[0]).map((header, index) => {
            if (display.has(header))
              return <TableHead key={index}>{header}</TableHead>;
          })}
        </TableRow>
      </TableHeader>
      <TableBody>
        {stores.map((s) => (
          <TableRow key={s.id}>
            <TableCell>{s.name}</TableCell>
            <TableCell>{s.locationId}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

export default StoreTable;
