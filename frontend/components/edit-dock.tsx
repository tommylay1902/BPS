"use client";
import React, { useState } from "react";
import { Button } from "./ui/button";
import { Trash, Plus } from "lucide-react";
import CreateStoreDialog from "@/app/stores/_components/dialog/create-store-dialog";
import { Store } from "@/app/stores/_types/store";
import DeleteStoreDialog from "@/app/stores/_components/dialog/delete-store-dialog";

interface EditDockProps {
  selectedStores: Store[];
}
export const EditDock: React.FC<EditDockProps> = ({ selectedStores }) => {
  const [createStoreDialogOpen, setCreateStoreDialogOpen] = useState(false);
  const [deleteStoreDialogOpen, setDeleteStoreDialogOpen] = useState(false);

  return (
    <>
      <CreateStoreDialog
        openState={createStoreDialogOpen}
        handleCreateStoreDialogState={setCreateStoreDialogOpen}
      />
      <DeleteStoreDialog
        openState={deleteStoreDialogOpen && selectedStores.length !== 0}
        handleDeleteStoreDialogState={setDeleteStoreDialogOpen}
        stores={selectedStores}
      />

      <div className="fixed bottom-8 left-1/2 flex -translate-x-1/2 transform animate-float-up gap-4 rounded-full bg-slate-700 p-4">
        <div className="group relative">
          <Button
            variant="destructive"
            onClick={() => {
              setDeleteStoreDialogOpen(true);
            }}
            className="peer/delete rounded-full cursor-pointer transition-all duration-300 hover:scale-110 group-hover/update:scale-90 [&_svg]:size-5"
          >
            <Trash />
          </Button>
        </div>
        <div className="group relative">
          <Button
            onClick={() => {
              setCreateStoreDialogOpen(true);
            }}
            className="peer/create cursor-pointer rounded-full transition-all duration-300 hover:scale-110 group-hover/update:scale-90 [&_svg]:size-5"
          >
            <Plus />
          </Button>
        </div>
      </div>
    </>
  );
};

export default EditDock;
