import * as React from "react";
import { Store } from "./_types/store";
import { DataTable } from "@/components/ui/data-table";
import columns from "@/app/stores/_components/columns";
import TableActions from "@/app/stores/_components/store-crud";

const Page: React.FC = async () => {
  const baseUrl = process.env.NEXT_PUBLIC_API_BASE_URL;
  const data = await fetch(`${baseUrl}/api/Store`);
  const stores: Store[] = await data.json();

  return (
    <>
      <TableActions />
      <DataTable columns={columns} data={stores} />
    </>
  );
};

export default Page;
