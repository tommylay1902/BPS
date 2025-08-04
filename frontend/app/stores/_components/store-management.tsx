"use client";
import React, { useState, useMemo } from "react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./table/columns";
import EditDock from "@/components/edit-dock";
import { Store } from "../_types/store";
import { RowSelectionState } from "@tanstack/react-table";

interface StoreManagementProps {
  data: Store[];
}
const StoreManagement: React.FC<StoreManagementProps> = ({ data }) => {
  const [selectedStoreIds, setSelectedStoreIds] = useState<RowSelectionState>(
    {},
  );

  const selectedStores = useMemo(() => {
    return Object.keys(selectedStoreIds)
      .filter((id) => selectedStoreIds[id])
      .map((id) => data.find((store) => store.id === id))
      .filter(Boolean) as Store[];
  }, [selectedStoreIds, data]);

  return (
    <div className="flex-1">
      <div className="text-center my-4 text-3xl font-bold">Manage Stores</div>
      <DataTable
        columns={columns}
        data={data}
        onRowSelectionChange={setSelectedStoreIds}
      />
      <EditDock selectedStores={selectedStores} />
    </div>
  );
};

export default StoreManagement;
