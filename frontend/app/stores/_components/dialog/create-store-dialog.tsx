"use client";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogDescription,
} from "@/components/ui/dialog";
import { useState, useEffect } from "react";

import StoreForm from "../forms/store-form";
import { toast } from "sonner";
import { Store } from "../../_types/store";
import { useStores } from "../../_context/stores-context";

interface CreateStoreDialogProps {
  openState: boolean;
  handleCreateStoreDialogState: (state: boolean) => void;
}
const CreateStoreDialog: React.FC<CreateStoreDialogProps> = ({
  openState,
  handleCreateStoreDialogState: handleCreateStoreDialogOpen,
}) => {
  const [open, setOpen] = useState(openState);
  useEffect(() => {
    setOpen(openState);
  }, [openState]);
  const onOpenChange = (newOpen: boolean) => {
    setOpen(newOpen);
    handleCreateStoreDialogOpen(newOpen);
  };

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Add Store</DialogTitle>
          <DialogDescription>Add Store Info Here</DialogDescription>
        </DialogHeader>
        <StoreForm handleCloseDialog={handleCreateStoreDialogOpen} />
      </DialogContent>
    </Dialog>
  );
};

export default CreateStoreDialog;
