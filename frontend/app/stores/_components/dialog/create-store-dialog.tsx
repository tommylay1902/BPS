import { Dialog, DialogContent, DialogTrigger } from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import StoreForm from "../forms/store-form";

const CreateStoreDialog = () => {
  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="outline">Add Store</Button>
      </DialogTrigger>
      <DialogContent>
        <StoreForm />
      </DialogContent>
    </Dialog>
  );
};

export default CreateStoreDialog;
