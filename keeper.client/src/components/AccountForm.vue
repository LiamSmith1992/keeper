<template>
  <div class="">
    <div>
      <form class="p-3">
        <div class="form-group">
          <label class="p-1" for="exampleFormControlInput1">Name</label>
          <input v-model="editable.name" required type="text" class="form-control" id="exampleFormControlInput1"
            placeholder="Name">
        </div>
        <div class="form-group">
          <label class="p-1" for="exampleFormControlInput1">Profile Picture</label>
          <input v-model="editable.picture" required type="text" class="form-control" id="exampleFormControlInput1"
            placeholder="Img Url">
        </div>
        <div class="form-group">
          <label class="p-1" for="exampleFormControlInput1">Cover Image</label>
          <input v-model="editable.coverImg" required type="url" class="form-control" id="exampleFormControlInput1"
            placeholder="Img Url">

        </div>
        <div class="text-end">

          <button @click.prevent="editAccount(account.id)" data-bs-toggle="modal"
            class="btn btn-success">Submit</button>
        </div>
      </form>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { accountService } from "../services/AccountService";
import { logger } from "../utils/Logger";
export default {
  setup() {
    const editable = ref({})


    return {
      editable,
      account: computed(() => AppState.account),

      async editAccount(accountId) {
        try {
          await accountService.edit(editable.value, accountId)
          Modal.getOrCreateInstance('#editForm').hide()
          Modal.getOrCreateInstance('#editForm').show()
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