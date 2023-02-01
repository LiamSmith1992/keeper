<template>
  <div>
    <form class="p-3">
      <div class="form-group">
        <label class="p-1" for="exampleFormControlInput1">Vault Name</label>
        <input v-model="editable.name" required type="text" class="form-control" id="exampleFormControlInput1"
          placeholder="Name">
      </div>
      <div class="form-group">
        <label class="p-1" for="exampleFormControlInput1">Description</label>
        <input v-model="editable.description" required type="text" class="form-control" id="exampleFormControlInput1"
          placeholder="Description">
      </div>
      <div class="form-group">
        <label class="p-1" for="exampleFormControlInput1">Image Url</label>
        <input v-model="editable.img" required type="url" class="form-control" id="exampleFormControlInput1"
          placeholder="Img Url">
        <div class=" m-1 form-check form-check-inline">
          <input v-model="editable.isPrivate" class=" p-1 form-check-input" type="checkbox" id="inlineCheckbox1"
            value="option1">
          <label class="form-check-label" for="inlineCheckbox1">Private</label>
        </div>
      </div>
      <div class="text-end">

        <button @click.prevent="createVault()" data-bs-toggle="modal" data-bs-target="#vaultForm"
          class="btn btn-success">Submit</button>
      </div>
    </form>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from "../utils/Logger";
import { vaultsService } from "../services/VaultsService";
import { router } from "../router";
import { useRouter } from "vue-router";
export default {
  setup() {
    const editable = ref({})
    const router = useRouter()


    return {
      editable,
      async createVault() {
        try {
          const vault = await vaultsService.createVault(editable.value)
          router.push({ name: 'Vault', params: { vaultId: vault.id } })
          editable.value = {}
          editable.value = {}
        } catch (error) {
          logger.error(error.message)
        }

      }




    }
  }
};
</script>


<style lang="scss" scoped>

</style>