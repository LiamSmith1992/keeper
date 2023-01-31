<template>
  <div v-if="keep" class="component">
    <section class="row ">
      <div class="d-flex justify-content-center bg-dark text-light">
        <p class="m-1">views:{{ keep.views }}</p>
        <P class="m-1">Kept: {{ keep.kept }}</P>
      </div>
    </section>
    <section class="d-flex row">
      <img class="img-height img-fluid col-6" :src="keep.img" alt="">
      <div class="col-6">
        <h1 class="text-center mt-2">{{ keep.name }}</h1>
        <h5 class="p-2">{{ keep.description }}</h5>
        <div class="d-flex align-items-end">
          <div class="dropdown">
            <button class=" btn btn-secondary dropdown-toggle" type="button" id="dropdownMenu2"
              data-bs-toggle="dropdown" aria-expanded="false">
              Dropdown
            </button>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">
              <li><button class="dropdown-item" type="button">Action</button></li>
              <li><button class="dropdown-item" type="button">Another action</button></li>
              <li><button class="dropdown-item" type="button">Something else here</button></li>
            </ul>
          </div>
          <button class="btn btn-success rounded-end">Save</button>
        </div>
      </div>
    </section>
  </div>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  setup() {



    return {
      keep: computed(() => AppState.activeKeep)
    }
  }
};
</script>


<style lang="scss" scoped>
.img-height {
  height: 55vh;
}
</style>