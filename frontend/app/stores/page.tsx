import React from "react";
import { Store } from "./_types/store";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./_components/table/columns";
import CreateStoreDialog from "./_components/dialog/create-store-dialog";
import EditDock from "@/components/edit-dock";

const StorePage = async () => {
  const baseUrl = process.env.NEXT_PUBLIC_API_BASE_URL;
  const response = await fetch(`${baseUrl}/api/Store`);
  const stores: Store[] = await response.json();

  return (
    <div className="flex-1">
      <div className="text-center my-4 text-3xl font-bold">Manage Stores</div>
      <CreateStoreDialog />
      <DataTable columns={columns} data={stores} />
      <EditDock />
    </div>
  );
};

export default StorePage;
