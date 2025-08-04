"use client";
import { useState, useEffect } from "react";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
} from "@/components/ui/dialog";
import { Store } from "../../_types/store";
import { Button } from "@/components/ui/button";

interface DeleteStoreDialogProps {
  openState: boolean;
  handleDeleteStoreDialogState: (state: boolean) => void;
  stores: Store[];
}
const DeleteStoreDialog: React.FC<DeleteStoreDialogProps> = ({
  openState,
  handleDeleteStoreDialogState,
  stores,
}) => {
  const [open, setOpen] = useState(openState);
  useEffect(() => {
    setOpen(openState);
  }, [openState]);

  const onOpenChange = (newOpen: boolean) => {
    setOpen(newOpen);
    handleDeleteStoreDialogState(newOpen);
  };

  const deleteStores = async () => {
    try {
      const idList = stores.map((store) => store.id).join(",");
      const encodedIds = encodeURIComponent(idList);

      await fetch(
        process.env.NEXT_PUBLIC_API_BASE_URL + "/api/Store?ids=" + encodedIds,
      );
    } catch (e) {
      console.error(e);
    }
  };

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Confirm delete</DialogTitle>
        </DialogHeader>

        {stores.map((store) => (
          <div key={store.id}>
            <div className="font-bold">Store Name </div>
            <div>{store.name}</div>
          </div>
        ))}
        <DialogFooter>
          <Button onClick={deleteStores}>Delete</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
};

export default DeleteStoreDialog;
