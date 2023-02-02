<template>
  <div>
    <form class="p-3">
      <div class="form-group">
        <label class="p-1" for="exampleFormControlInput1">Keep Name</label>
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

      </div>
      <div class="text-end">

        <button @click.prevent="createKeep()" data-bs-toggle="modal" data-bs-target="#keepForm"
          class="btn btn-success">Submit</button>
      </div>
    </form>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from "../utils/Logger";
import { keepsService } from "../services/KeepsService";
import { router } from "../router";
import { useRouter } from "vue-router";
export default {
  setup() {
    const editable = ref({})
    const router = useRouter()



    return {

      editable,
      async createKeep() {
        try {
          const keep = await keepsService.createKeep(editable.value)
          Modal.getOrCreateInstance('#keepForm').hide()
          Modal.getOrCreateInstance('#keepDetails').show()
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