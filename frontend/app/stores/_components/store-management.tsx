"use client";
import React, { useState, useMemo } from "react";
import { DataTable } from "@/components/ui/data-table";
import { columns } from "./table/columns";
import EditDock from "@/components/edit-dock";
import { Store } from "../_types/store";
import { RowSelectionState } from "@tanstack/react-table";
import { useStores } from "../_context/stores-context";

const StoreManagement: React.FC = () => {
  const [selectedStoreIds, setSelectedStoreIds] = useState<RowSelectionState>(
    {},
  );
  const { stores } = useStores();

  const selectedStores = useMemo(() => {
    return Object.keys(selectedStoreIds)
      .filter((id) => selectedStoreIds[id])
      .map((id) => stores.find((store) => store.id === id))
      .filter(Boolean) as Store[];
  }, [selectedStoreIds, stores]);

  return (
    <div className="flex-1">
      <div className="text-center my-4 text-3xl font-bold">Manage Stores</div>
      <DataTable
        columns={columns}
        data={stores}
        onRowSelectionChange={setSelectedStoreIds}
      />
      <EditDock selectedStores={selectedStores} />
    </div>
  );
};

export default StoreManagement;
